<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarSolicitante.aspx.cs" Inherits="Atensoli.Vista.BuscarSolicitante" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %> 

<!DOCTYPE HTML>

<html>
	<head>
		<title>Cellper | Agregar usuario</title>
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
		    $('#txtCedulaSolicitante').simpleAutoComplete('Autocomplete.aspx', {
				autoCompleteClassName: 'autocomplete',
				selectedClassName: 'sel',
				attrCallBack: 'rel',
				identifier: 'Solicitante'
			}, fnPersonalCallBack);

		});

		function fnPersonalCallBack(par) {
			document.getElementById("hdnSolicitanteID").value = par[0]; //par[0] id
			document.getElementById("txtCedulaSolicitante").value = par[1];
			//document.getElementById("txtDescripcion").value = par[2];
		}

	</script>

	</head>
	<body>
		<!-- Wrapper -->
			<div id="wrapper">

				<!-- Main -->
					<div id="main">
						<div class="inner">

							<!-- Header -->
								<header id="header">
									<a class="logo"><strong>Buscar solicitante</strong></a>
									<ul class="icons">

									</ul>
								</header>

							<!-- Content -->
							<form runat ="server" id ="principal">	
								<section>
										<p></p>
										<div class="row uniform">
											<div class="6u 12u$(xsmall)">
												<asp:TextBox ID="txtCedulaSolicitante" runat="server" placeholder="Indique el numero de cedula del solicitante" ></asp:TextBox>
												<asp:HiddenField runat ="server" ID ="hdnSolicitanteID"  Value="0"/>
												<ASP:RequiredFieldValidator id="rqrValidaCedula" runat="server" errormessage="Debe colocar el numero de cedula"  controltovalidate="txtCedulaSolicitante" display="Dynamic"></ASP:RequiredFieldValidator>
											</div>
											<div class="12u$">
												<ul class="actions">
													<li><asp:Button Text="Siguiente" runat="server" ID ="btnSiguiente"  CssClass ="special"  /></li>
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
