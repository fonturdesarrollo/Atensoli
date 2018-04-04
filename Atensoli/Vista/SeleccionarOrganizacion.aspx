﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarOrganizacion.aspx.cs" Inherits="Atensoli.SeleccionarOrganizacion" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Atensoli | Seleccionar Organización</title>
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
									<a class="logo"><strong><asp:Label runat ="server" ID ="lblTitulo" Text="Seleccionar organización"></asp:Label></strong></a>
									<ul class="icons">
										<asp:Label runat ="server" ID ="lblTitulo2" Text="Tipo de solicitud"></asp:Label>
									</ul>
								</header>

							<!-- Content -->
							<form runat ="server" id ="principal">	
								<section>
										<p></p>
										<div class="row uniform">
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtRifOrganzacion" MaxLength="10" onkeypress="return event.keyCode!=13;" placeholder ="Indique el RIF de la organización" pattern="^([JG]{1})([0-9]{9,10})$" title="El primer caracter debe ser J o G mayuscula seguido del numero de RIf G200062894"/> 
												<ASP:RequiredFieldValidator id="rqrValidaRif" runat="server" errormessage="Debe colocar el RIF de la organización"  controltovalidate="txtRifOrganzacion" ForeColor ="Red" display="Dynamic"></ASP:RequiredFieldValidator>
											</div>

											<div class="12u$">
												<ul class="actions">
													<asp:Button Text="Siguiente" runat="server" ID ="btnSiguiente"  CssClass ="special" OnClick="btnSiguiente_Click" />
												</ul>
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


