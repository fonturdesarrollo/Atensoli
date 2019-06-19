<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorrespondenciaSeleccionGerencia.aspx.cs" Inherits="Atensoli.CorrespondenciaSeleccionGerencia" %>

<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Atensoli | Selección de Correspondencia</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />

<%--        SCRIPTS--%>
		<link rel="stylesheet"  href="../Styles/jquery-ui-1.8rc3.custom.css"  />
		<script src="../assets/js/jquery.min.js"></script>
		<link rel="stylesheet" href="../assets/css/main.css" />
		<link rel="stylesheet" href="../Styles/simpleAutoComplete.css"  />
		<script src="../js/Util.js" type="text/javascript"></script>
<%--        <script src="../js/jquery.js"></script>--%>      
		
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
										<strong><asp:Label runat ="server" ID ="lblTitulo" Text="Selección de Correspondencia"></asp:Label></strong>
									</a>
									<ul class="icons">
										<asp:HyperLink runat="server" ID="lnkInicio" Text ="Inicio" NavigateUrl="~/Vista/Principal.aspx" ></asp:HyperLink>
									</ul>
								</header>

							<!-- Content -->
							<form runat ="server" id ="principal">	
								<section>
										<p></p>
											<div class="posts">
												<article>
													<asp:TextBox runat ="server" ID ="txtNumeroCorespondencia" placeholder ="Número de la correspondencia"></asp:TextBox>
												</article>
											   <article>
													<asp:Button Text="Consultar" runat="server" ID ="btnConsultar"  CssClass ="special" OnClick="btnConsultar_Click"  />
											   </article>
										   </div>
											<p></p>
											<div class="table-wrapper">
										        <asp:GridView ID="gridDetalle" runat="server" 
											        CssClass="subtitulo" 
											        EmptyDataText="No existen Registros" 
											        GridLines="Horizontal" 
											        AutoGenerateColumns="False" OnRowCommand="gridDetalle_RowCommand">
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
														        <asp:Label runat="server" ID="lblFecha" Text='<%# Eval("FechaCortaCorrespondencia") %>'  ></asp:Label>
													        </ItemTemplate>
												        </asp:TemplateField>
												        <asp:TemplateField HeaderText="Fecha Carga Correspondencia">
													        <ItemTemplate>
														        <asp:Label runat="server" ID="lblFechaCarga" Text='<%# Eval("FechaCargaCorrespondencia") %>'  ></asp:Label>
													        </ItemTemplate>
												        </asp:TemplateField>
												        <asp:TemplateField HeaderText="Usuario">
													        <ItemTemplate>
														        <asp:Label runat="server" ID="lblUsuario" Text='<%# Eval("Usuario") %>'  ></asp:Label>
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
												        <asp:TemplateField HeaderText="Acciones">
													        <ItemTemplate>
														        <asp:ImageButton runat="server" ID="btnSeguimiento" AlternateText="Seleccionar correspondencia" ToolTip="Seleccionar correspondencia" ImageUrl="~/images/asignar_estatus_icono.png"  CommandName="SeleccionarCorrespondencia"  CommandArgument='<%# Eval("CorrespondenciaID") %>'  CausesValidation ="false"/> 
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
