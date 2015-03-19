<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Resume.aspx.cs" Inherits="Resume" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<link rel="stylesheet" type="text/css" href="CSS/Styles.css"/>
	<title>GAME ON!</title>
</head>
<body>
	<form id="form1" runat="server">
	<div id = "main">
	
		<asp:Label ID="lblPrenom" runat="server"></asp:Label>
		<asp:Label ID="lblNom" runat="server"></asp:Label>
		<asp:Label ID="lblNumero" runat="server"></asp:Label>
		<asp:Table ID="tbInscriptions" runat="server">
		</asp:Table>
	
		<asp:Button ID="btnRetour" runat="server" OnClick="btnRetour_Click" Text="Retour" CssClass="button" />
	
	</div>
	</form>
</body>
</html>
