<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TP2.aspx.cs" Inherits="TP2" %>

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
		  <h1>GAME ON!</h1>
		  <p>
			  Cliquez sur la date où le tournoi se déroule pour commencer,
			  les autres options s'afficheront ensuite. Pour s&#39;inscrire à une compétition, choisissez
			  votre jeu, le plancher où vous allez disputer votre match et l'heure à laquelle
			  cela se passera. Si vous souhaitez annuler un de vos matchs, cliquer sur modifier, sélectionner le/les match(s) que vous voulez suprimer et cliquer sur le boutton . Pour
			  terminer votre inscription, remplissez les informations requisent et appuyez sur
			  confirmer.
		  </p>
		  <asp:Calendar ID="calendrierEvenement" runat="server" OnDayRender="calendrierEvenement_DayRender" OnSelectionChanged="calendrierEvenement_SelectionChanged" ShowNextPrevMonth="False">
			  <SelectedDayStyle BackColor="#084BD7" />
			  <TitleStyle Font-Bold="True" />
			</asp:Calendar>
			<asp:Label ID="lblEvenement" runat="server" CssClass="subTitles"></asp:Label>
		  <asp:Panel ID="pnlEvenement" runat="server" Visible="False">
			<asp:Label ID="lblJeu" runat="server" Text="Jeu : "></asp:Label>
			<asp:DropDownList ID="ddlJeu" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlJeu_SelectedIndexChanged">
			</asp:DropDownList>
			<asp:Label ID="lblPlancher" runat="server" Text="Plancher : "></asp:Label>
			<asp:DropDownList ID="ddlPlancher" runat="server">
			</asp:DropDownList>
			<asp:Label ID="lblHeure" runat="server" Text="Heure : "></asp:Label>
			<asp:DropDownList ID="ddlHeure" runat="server">
			</asp:DropDownList>
			<asp:Button ID="btnAjouter" runat="server" Text="Ajouter" OnClick="btnAjouter_Click" CssClass="button" />
			  <br />
			  <asp:Panel ID="pnlEditionInscription" runat="server">
				  <asp:CheckBoxList ID="cblInscriptions" runat="server">
				  </asp:CheckBoxList>
				  <asp:Button ID="btnModifier" runat="server" CssClass="alignLeft button" OnClick="btnModifier_Click" Text="Modifier" Visible="False" />
				  <asp:Button ID="btnSuprimerSelection" runat="server" CssClass="alignLeft button" OnClick="btnSuprimerSelection_Click" Text="Suprimer la sélection" Visible="False" />
			  </asp:Panel>
			  <br />
			  <asp:Label ID="lblInformations" runat="server" Text="Informations :" CssClass="subTitles"></asp:Label>
			  <asp:Panel ID="pnlInformations" runat="server">
				  <asp:Label ID="lblPrenom" runat="server" CssClass="alignLeft" Text="Prénom :"></asp:Label>
				  <asp:TextBox ID="txtbPrenom" runat="server" CssClass="alignLeft"></asp:TextBox>
				  <asp:Label ID="lblNom" runat="server" CssClass="alignLeft" Text="Nom :"></asp:Label>
				  <asp:TextBox ID="txtbNom" runat="server" CssClass="alignLeft"></asp:TextBox>
				  <asp:Label ID="lblNoMembre" runat="server" CssClass="alignLeft" Text="Numéro de membre :"></asp:Label>
				  <asp:TextBox ID="txtbNoMembre" runat="server" CssClass="alignLeft"></asp:TextBox>
			  </asp:Panel>
			<asp:Button ID="btnConfirmer" runat="server" Text="Confirmer" OnClick="btnConfirmer_Click" CssClass="button" />
			  <asp:Button ID="btnAnnuler" runat="server" Text="Annuler" OnClick="btnAnnuler_Click" CssClass="button" />
		  </asp:Panel>
		</div>
	</form>
</body>
</html>
