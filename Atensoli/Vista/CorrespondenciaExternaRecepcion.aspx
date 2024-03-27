<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorrespondenciaExternaRecepcion.aspx.cs" Inherits="Atensoli.CorrespondenciaExternaRecepcion" %>

<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>


<!DOCTYPE HTML>

<html>
	<head>
		<title>Atensoli | Recepción de Correspondencia Externa</title>
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
				$('#txtNombreRemitente').simpleAutoComplete('Autocomplete.aspx', {
					autoCompleteClassName: 'autocomplete',
					selectedClassName: 'sel',
					attrCallBack: 'rel',
					identifier: 'CorrespondenciaRemitente'
				}, fnPersonalCallBack);

				function fnPersonalCallBack(par) {
					document.getElementById("hdnRemitenteID").value = par[0];
					document.getElementById("txtNombreRemitente").value = par[1];
				}
			});


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

			$("#txtFechaCorrespondencia").datepicker({
				dateFormat: 'dd/mm/yy',  buttonImageOnly: false, changeMonth: true,
				changeYear: true, gotoCurrent: true, yearRange: "2000:2030"
			});
		});

		function Confirmacion() {

		    return confirm("¿Realmente desea eliminar este registro?");
		}

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
									<a class="logo"><strong><asp:Label runat ="server" ID ="lblTitulo" Text="Recepción de Correspondencia Externa"></asp:Label></strong></a>
									<ul class="icons">

									</ul>
								</header>
							<!-- Content -->
							<form runat ="server" id ="principal">
								<section>
									<p></p>
										<div class="row uniform">
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlTipoCorrespondencia" runat="server"  AppendDataBoundItems="True"  >
													</asp:DropDownList>
												</div>
												<ASP:RequiredFieldValidator id="rqrvalidaTipoCorrespondencia" runat="server" errormessage="Debe seleccionar el tipo de correspondencia"  controltovalidate="ddlTipoCorrespondencia" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)"> 
												<asp:TextBox runat="server" ID="txtNombreRemitente"  MaxLength="80"  placeholder="Nombre del remitente" />
												<ASP:RequiredFieldValidator id="rqrvalidaNombreRemitente" runat="server" errormessage="Debe colocar el nombre del remitente"  controltovalidate="txtNombreRemitente" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												<asp:HiddenField runat ="server" ID ="hdnRemitenteID"  Value="0"/> 
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlEstado" runat="server"  AppendDataBoundItems="True"  >
													</asp:DropDownList>
												</div>
												<ASP:RequiredFieldValidator id="rqrValidaEstado" runat="server" errormessage="Debe seleccionar el estado"  controltovalidate="ddlEstado" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtFechaCorrespondencia"  MaxLength="20" placeholder ="Fecha de la correspondencia"/>
												<ASP:RequiredFieldValidator id="rqrValidaFechaCorrespondencia" runat="server" errormessage="Debe colocar la fecha de la correspondencia" controltovalidate="txtFechaCorrespondencia" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
									   </div>
										<div class="row uniform">
											   <div class="12u$">
													<asp:TextBox runat="server" ID="txtContenido" TextMode="MultiLine" Rows="2" MaxLength="3000"  placeholder="Resumen del contenido de la correspondencia"/> 
													<ASP:RequiredFieldValidator id="rqrValidaContenido" runat="server" errormessage="Debe colocar el resumen del contenido de la correspondencia"  controltovalidate="txtContenido" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												</div>
										</div>
										<div class="row uniform">
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlPrioridad" runat="server"  AppendDataBoundItems="True"  >
													</asp:DropDownList>
												</div>
												<ASP:RequiredFieldValidator id="rqrValidaPrioridad" runat="server" errormessage="Debe seleccionar la prioridad"  controltovalidate="ddlPrioridad" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlGerencia" runat="server"  AppendDataBoundItems="True"  >
													</asp:DropDownList>
												</div>
												<ASP:RequiredFieldValidator id="rqrValidaGerencia" runat="server" errormessage="Debe seleccionar la gerencia a remitir"  controltovalidate="ddlGerencia" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
										</div>
										<p></p>
										<div class="12u$">
											<ul class="actions">
												<li><asp:Button Text="Registrar correspondencia externa" runat="server" ID ="btnGuardar"  CssClass ="special" OnClick="btnGuardar_Click"  /></li>
												<li><asp:Button  runat="server" ID="btnNuevo" Text ="Nuevo registro"  CausesValidation ="false" OnClick="btnNuevo_Click" /></li>
												<asp:FileUpload ID="FileUploadControl"  runat="server" AllowMultiple="true" />
												<asp:Button ID="UploadButton" runat="server" Text="Adjuntar documentos" OnClick="UploadButton_Click" CausesValidation = "false" />
												<li><asp:Label ID="StatusLabel" runat="server" Text=""></asp:Label></li>												
											</ul>
										</div>
									
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
												<asp:TemplateField HeaderText="Fecha Correspondencia">
													<ItemTemplate>
														<asp:Label runat="server" ID="lblFecha" Text='<%# Eval("FechaCorrespondencia") %>'  ></asp:Label>
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
												<asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100">
													<ItemTemplate>
													<asp:ImageButton runat="server" ID="btnModificar" AlternateText="Eliminar correspondencia" ToolTip="Eliminar correspondencia" ImageUrl="~/images/eliminar.png" OnClientClick="return Confirmacion();" CommandName="EliminarCorrespondencia"  CommandArgument='<%# Eval("CorrespondenciaID") %>'  CausesValidation ="false"/> 
													</ItemTemplate>
												</asp:TemplateField>
											</Columns>
										</asp:GridView>
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
