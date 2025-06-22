<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorrespondenciaInterna.aspx.cs" Inherits="Atensoli.Vista.CorrespondenciaInterna" %>

<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<title>Correspondencia Interna | Seleccionar / Agregar</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
		<%--        SCRIPTS--%>
				<link rel="stylesheet"  href="../Styles/jquery-ui-1.8rc3.custom.css"  />
				<script src="../assets/js/jquery.min.js"></script>
				<link rel="stylesheet" href="../assets/css/main.css" />
				<link rel="stylesheet" href="../Styles/simpleAutoComplete.css"  />
				<link href="../Plugins/datatables.css" rel="stylesheet" /> 
				<script src="../Plugins/datatables.js"></script>
				<link rel="stylesheet" href="../assets/css/bootstrap.css" />

				<script src="../js/Util.js" type="text/javascript"></script>
				<script src="../assets/js/skel.min.js"></script>
				<script src="../assets/js/util.js"></script>
				<script src="../assets/js/main.js"></script> 
				<script src="../assets/js/bootstrap.js"></script>   	
			<%--------------------------%>


		<script type="text/javascript">
            jQuery(document).ready(function ($) {
                var dataTableSettings = {
                    "paging": true,
                    "lengthChange": false,
                    "searching": true,
                    "ordering": true,
                    "info": true,
                    "autoWidth": false,
                    "responsive": true,
                    "aoColumns": [
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                    ],
                    "language": {
                        "sEmptyTable": "No hay datos disponibles en la tabla",
                        "sInfo": "Mostrando _START_ a _END_ de _TOTAL_ entradas",
                        "sInfoEmpty": "Mostrando 0 a 0 de 0 entradas",
                    },
                    "iDisplayLength": 10
                };

                //dataTable = $('#dataTableRecibidas').dataTable(dataTableSettings);
                //dataTable = $('#dataTableRemitidas').dataTable(dataTableSettings);
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
									<a class="logo">
										<strong><asp:Label runat ="server" ID ="lblTitulo" Text="Correspondencias Internas Registradas"></asp:Label></strong>
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
													<div class="14u 12u$(xsmall)">
														<div class="select-wrapper">
															<asp:DropDownList ID="ddlGerencia" runat="server"  AppendDataBoundItems="True"  >
															</asp:DropDownList>
														</div>														
													</div>
												</article>
											   <article>
													<asp:Button Text="Generar correspondencia" runat="server" ID ="btnConsultar"  CssClass ="special" OnClick="btnConsultar_Click"  />
											   </article>
										   </div>
											<p></p>
											<div class="container">
												<ul class="nav nav-tabs">
													<li class="active"><a data-toggle="tab" href="#home">Recibidas</a></li>
													<li><a data-toggle="tab" href="#menu1">Enviadas</a></li>
												</ul>
											</div>

											<div class="tab-content">
													<div id="home" class="tab-pane fade in active">
														<table id="dataTableRecibidas" class="display" style="width:100%" runat="server">
															<thead>
																<tr>
																	<th>N°</th>
																	<th>Tipo</th>
																	<th>Remitente</th>
																	<th>Estado</th>
																	<th>Fecha</th>
																	<th>Asunto</th>
																	<th>Prioridad</th>
																	<th>Gerencia Actual</th>
																	<th>Estatus</th>
																</tr>
															</thead>
															<tbody>

															</tbody>
														</table>
													</div>
													<div id="menu1" class="tab-pane fade">
														<table id="dataTableRemitidas" class="display" style="width:100%" runat="server">
															<thead>
																<tr>
																	<th>N°</th>
																	<th>Tipo</th>
																	<th>Remitente</th>
																	<th>Estado</th>
																	<th>Fecha</th>
																	<th>Asunto</th>
																	<th>Prioridad</th>
																	<th>Gerencia Actual</th>
																	<th>Estatus</th>
																</tr>
															</thead>
															<tbody>

															</tbody>
														</table>
													</div>
											</div>
								</section>
							</form>
						</div>
					</div>
					<uc2:UCNavegacion  runat ="server" ID ="ControlMenu"/>
				</div>
</body>
</html>

