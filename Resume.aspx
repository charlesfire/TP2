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
	
		<asp:Label ID="lblResume" runat="server" CssClass="subTitles" Text="Résumé"></asp:Label>
		<br />
		Nous avons reçu,
	
		<asp:Label ID="lblPrenom" runat="server"></asp:Label>
		&nbsp;<asp:Label ID="lblNom" runat="server"></asp:Label>
		, votre demande de réservation en date du
		<asp:Label ID="lblDate" runat="server"></asp:Label>
		pour les matchs suivants :<br />
		<br />
		<asp:Table ID="tbInscriptions" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" GridLines="Both" HorizontalAlign="Center">
			<asp:TableRow runat="server" BackColor="Gray" Font-Bold="True" ForeColor="White">
				<asp:TableCell runat="server">Événement</asp:TableCell>
				<asp:TableCell runat="server">Jeu</asp:TableCell>
				<asp:TableCell runat="server">Plancher</asp:TableCell>
				<asp:TableCell runat="server">Date</asp:TableCell>
				<asp:TableCell runat="server">Heure</asp:TableCell>
			</asp:TableRow>
		</asp:Table>
	
		<br />
		<asp:Label ID="lblDemandeFaitPar" runat="server" CssClass="subTitles" Text="Demande faite par"></asp:Label>
		<br />
		<asp:Label ID="lblNumero" runat="server"></asp:Label>
		<br />
		<br />
		<br />
		<br />
		<asp:Label ID="lblNote" runat="server" ForeColor="Red" Text="Note : Veuillez imprimer et conserver ce document. Il est la preuve que vous vous êtes bien inscrit aux match ci-dessus."></asp:Label>
		<br />
		<br />
		<asp:Button ID="btnRetour" runat="server" OnClick="btnRetour_Click" Text="Retour" CssClass="button" />
	
	</div>
	</form>
</body>
</html>
