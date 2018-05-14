<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorrespondenciaRecepcionGerencia.aspx.cs" Inherits="Atensoli.CorrespondenciaRecepcionGerencia" %>

<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>


<!DOCTYPE HTML>
<html>
	<head>
		<title>Atensoli | Actualizar correspondencia</title>
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
										<strong><asp:Label runat ="server" ID ="lblTitulo" Text="Actualizar correspondencia"></asp:Label></strong>
									<ul class="icons">
									</ul>
								</header>
							<!-- Content -->
							<form runat ="server" id ="principal">
								<section>
									<p></p>
											<div class="row uniform">
												<div class="6u 12u$(xsmall)">
													<asp:Button  runat ="server" ID="btnGuardar" Text ="Actualizar correspondencia" CssClass ="special" OnClick="btnGuardar_Click"/>
												</div>
												<div class="6u 12u$(xsmall)">
													<asp:Button  runat ="server" ID="btnHistorial" Text ="Historial" CausesValidation="False" OnClick="btnHistorial_Click"/>
												</div>
											</div>
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
														<asp:TemplateField HeaderText="N°">
															<ItemTemplate>
																<asp:Label runat="server" ID="lblNumero" Text='<%# Eval("CorrespondenciaID") %>'  ></asp:Label>
															</ItemTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Fecha Correspondencia">
															<ItemTemplate>
																<asp:Label runat="server" ID="lblFecha" Text='<%# Eval("FechaCorrespondencia") %>'  ></asp:Label>
															</ItemTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Tipo" >
															<ItemTemplate>
																<asp:Label runat="server" ID="lblTipo" Text='<%# Eval("NombreTipoCorrespondencia") %>'  ></asp:Label>
															</ItemTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Nombre remitente" >
															<ItemTemplate>
																<asp:Label runat="server" ID="lblRemitente" Text='<%# Eval("NombreCorrespondenciaRemitente") %>'  ></asp:Label>
															</ItemTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Estado">
															<ItemTemplate>
																<asp:Label runat="server" ID="lblEstado" Text='<%# Eval("NombreEstado") %>'  ></asp:Label>
															</ItemTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Contenido">
															<ItemTemplate>
																<asp:Label runat="server" ID="lblContenido" Text='<%# Eval("ContenidoCorrespondencia") %>'  ></asp:Label>
															</ItemTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Prioridad">
															<ItemTemplate>
																<asp:Label runat="server" ID="lblPrioridad" Text='<%# Eval("NombreCorrespondenciaPrioridad") %>'  ></asp:Label>
															</ItemTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Gerencia">
															<ItemTemplate>
																<asp:Label runat="server" ID="lblGerencia" Text='<%# Eval("NombreGerencia") %>'  ></asp:Label>
															</ItemTemplate>
														</asp:TemplateField>
													</Columns>
												</asp:GridView>
											</div>

										<div class="posts">
											<article> 
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlInstruccion" runat="server"  AppendDataBoundItems="True"  ></asp:DropDownList>
												</div>
												<ASP:RequiredFieldValidator id="rqrValidaInstruccion" runat="server" errormessage="Debe indicar la instrucción"  controltovalidate="ddlInstruccion" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</article>
											<article> 
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlGerencia" runat="server"  AppendDataBoundItems="True"  ></asp:DropDownList>
												</div>
												<ASP:RequiredFieldValidator id="rqrValidaGerencia" runat="server" errormessage="Debe el indicar remitido"  controltovalidate="ddlGerencia" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</article>
											<article> 
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlEstatus" runat="server"  AppendDataBoundItems="True"  ></asp:DropDownList>
												</div>
												<ASP:RequiredFieldValidator id="rqrValidaEstatus" runat="server" errormessage="Debe el indicar el estatus de la correspondencia"  controltovalidate="ddlEstatus" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</article>
										</div>
										<div class="row uniform">
											   <div class="12u$">
													<asp:TextBox runat="server" ID="txtObservaciones" TextMode="MultiLine" Rows="3" MaxLength="3000"  placeholder="Observaciones a la correspondencia"/> 
													<ASP:RequiredFieldValidator id="rqrValidaContenido" runat="server" errormessage="Debe colocar las observaciones"  controltovalidate="txtObservaciones" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
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
	</body>
</html>
