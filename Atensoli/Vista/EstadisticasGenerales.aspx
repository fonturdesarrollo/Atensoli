<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstadisticasGenerales.aspx.cs" Inherits="Atensoli.EstadisticasGenerales" %>

<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Atensoli | Estadísticas Generales</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />

<%--        SCRIPTS--%>
		<link rel="stylesheet"  href="../Styles/jquery-ui-1.8rc3.custom.css"  />
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
	<script type ="text/javascript">

		$(function () {

			//Array para dar formato en español
			$.datepicker.regional['es'] =
			{
				closeText: 'Cerrar',
				prevText: 'Previo',
				nextText: 'Próximo',

				monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
				'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
				monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
				'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
				monthStatus: 'Ver otro mes', yearStatus: 'Ver otro año',
				dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
				dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sáb'],
				dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
				dateFormat: 'dd/mm/yy', firstDay: 0,
				initStatus: 'Selecciona la fecha', isRTL: false
			};
			$.datepicker.setDefaults($.datepicker.regional['es']);

			$("#txtFechaRegistro").datepicker({
				dateFormat: 'dd/mm/yy',  buttonImageOnly: false, changeMonth: true,
				changeYear: true, gotoCurrent: true, yearRange: "1900:2020"
			});
			$("#txtFechaHasta").datepicker({
				dateFormat: 'dd/mm/yy', buttonImageOnly: false, changeMonth: true,
				changeYear: true, gotoCurrent: true, yearRange: "1900:2020"
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
									<a class="logo"><strong><asp:Label runat ="server" ID ="lblTitulo" Text ="Estadísticas Generales"></asp:Label></strong>

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
														<asp:TextBox runat="server" ID="txtFechaRegistro"  MaxLength="20" placeholder ="Fecha desde"/>
														<ASP:RequiredFieldValidator id="rqrValidaFechaRegistro" runat="server" errormessage="Debe colocar la fecha desde"  controltovalidate="txtFechaRegistro" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												</article>
			
												<article>
														<asp:TextBox runat="server" ID="txtFechaHasta"  MaxLength="20" placeholder ="Fecha hasta"/>
														<ASP:RequiredFieldValidator id="rqrValidaFechaHasta" runat="server" errormessage="Debe colocar la fecha hasta"  controltovalidate="txtFechaHasta" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												</article>
											
												<article>
													<asp:Button runat ="server" ID ="btnConsultar"   Text ="Consultar"  CssClass  ="special" OnClick="btnConsultar_Click"/>
												</article>											
											</div>
												<div class="table-wrapper">
												<asp:Label runat ="server" ID ="Label2" Text ="Total transportistas atendidos" Font-Bold ="true" ForeColor ="Red"></asp:Label>
												  <asp:GridView ID="gridDetalle4" runat="server" 
													  ShowFooter ="true" 
													  AutoGenerateColumns="False" OnRowDataBound="gridDetalle4_RowDataBound">
														  <Columns>
															  <asp:TemplateField HeaderText="Estado" HeaderStyle-Width ="1500">
																  <ItemTemplate>
													            <asp:Label runat="server" ID="lblNomEstado" Text='<%# Eval("NombreEstado") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
															  <asp:TemplateField HeaderText="Total" >
																  <ItemTemplate>
																	  <asp:Label runat="server" ID="lblFechaSolicitud" Text='<%# Eval("Total") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
														 </Columns>
												  </asp:GridView>
												</div>
												<div class="table-wrapper">
												<asp:Label runat ="server" ID ="lblTituloEstado" Text ="Total solicitudes por estado" Font-Bold ="true" ForeColor ="Red"></asp:Label>
												  <asp:GridView ID="gridDetalle" runat="server" 
													  ShowFooter ="true" 
													  AutoGenerateColumns="False" OnRowDataBound="gridDetalle_RowDataBound">
														  <Columns>
															  <asp:TemplateField HeaderText="Estado" HeaderStyle-Width ="1500">
																  <ItemTemplate>
																	  <asp:Label runat="server" ID="lblEstado" Text='<%# Eval("NombreEstado") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
															  <asp:TemplateField HeaderText="Total" >
																  <ItemTemplate>
																	  <asp:Label runat="server" ID="lblFechaSolicitud" Text='<%# Eval("Total") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
														 </Columns>
												  </asp:GridView>
												</div>

												<div class="table-wrapper">
												<asp:Label runat ="server" ID ="lblTituloSolicitud" Text ="Total solicitudes por tipo solicitud" Font-Bold ="true" ForeColor ="Red"></asp:Label>
												  <asp:GridView ID="gridDetalle2" runat="server"
														  ShowFooter ="true" 
														  AutoGenerateColumns="False" OnRowDataBound="gridDetalle2_RowDataBound">
														  <Columns>
															  <asp:TemplateField HeaderText="Tipo de Solicitud" HeaderStyle-Width ="1500">
																  <ItemTemplate>
																	  <asp:Label runat="server" ID="lblNombreTipoSol" Text='<%# Eval("NombreTipoSolicitud") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
															  <asp:TemplateField HeaderText="Total" >
																  <ItemTemplate>
																	  <asp:Label runat="server" ID="lblFechaSolicitud" Text='<%# Eval("Total") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
														 </Columns>
												  </asp:GridView>
												</div>

												<div class="table-wrapper">
													<asp:Label runat ="server" ID ="Label1" Text ="Total solicitudes por tipo remitido" Font-Bold ="true" ForeColor ="Red"></asp:Label>
													<asp:GridView ID="gridDetalle3" runat="server" 
													  ShowFooter ="true" 
													  AutoGenerateColumns="False" OnRowDataBound="gridDetalle3_RowDataBound">
														  <Columns>
															  <asp:TemplateField HeaderText="Tipo de remitido" HeaderStyle-Width ="1500">
																  <ItemTemplate>
																	  <asp:Label runat="server" ID="lblNombreTipoRem" Text='<%# Eval("NombreTipoRemitido") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
															  <asp:TemplateField HeaderText="Total" >
																  <ItemTemplate>
																	  <asp:Label runat="server" ID="lblFechaSolicitud" Text='<%# Eval("Total") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
														 </Columns>
												  </asp:GridView>
											</div>
								</section>
							</form>
						</div>
					</div>
			</div>
				<!-- Sidebar -->
<%--					<div id="sidebar">
						<div class="inner">--%>
							<!-- Menu -->
								<%--<uc2:UCNavegacion  runat ="server" ID ="ControlMenu"/>--%>
<%--						</div>
					</div>--%>
			<%--</div>--%>
		<!-- Scripts -->

<%--        SE COLOCARON EN EL HEADER --%>

	</body>
</html>
