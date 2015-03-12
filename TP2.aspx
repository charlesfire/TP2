﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TP2.aspx.cs" Inherits="TP2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <h1>GAME ON!</h1>
    </div>
      <p>
        Explication sur la page: Cliquez sur la date où le toournoi se déroule pour commencer,
          les autres options s'afficheront ensuite. Pour intégrer la compétition, choisissez
          votre jeu, le plancher où vous allez disputer votre match et l'heure à laquelle
          cela se passe. Si vous changez d'avis ou vous souhaitez vous retirer, cliquer sur
          modifier et sélectionner les évènements que vous voulez changer. Dans le cas d'un
          abandon, sélectionnez les les activités et appuyez sur le bouton supprimer. Pour
          terminer votre inscription, remplissez les informations requisent et appuyez sur
          confirmer.
      </p>
      <asp:Calendar ID="calendrierEvenement" runat="server" OnDayRender="calendrierEvenement_DayRender" OnSelectionChanged="calendrierEvenement_SelectionChanged" ShowNextPrevMonth="False"></asp:Calendar>
        <asp:Label ID="lblEvenement" runat="server"></asp:Label>
      <asp:Panel ID="pnlEvenement" runat="server" Enabled="False">
        <asp:Label ID="lblJeu" runat="server" Text="Jeu : "></asp:Label>
        <asp:DropDownList ID="ddlJeu" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlJeu_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Label ID="lblPlancher" runat="server" Text="Plancher : "></asp:Label>
        <asp:DropDownList ID="ddlPlancher" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <asp:Label ID="lblHeure" runat="server" Text="Heure : "></asp:Label>
        <asp:DropDownList ID="ddlHeure" runat="server">
        	<asp:ListItem>13h00</asp:ListItem>
			<asp:ListItem>15h00</asp:ListItem>
			<asp:ListItem>17h00</asp:ListItem>
			<asp:ListItem>19h00</asp:ListItem>
			<asp:ListItem>21h00</asp:ListItem>
			<asp:ListItem>23h00</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnAjouter" runat="server" Text="Ajouter" />
          <br />
        <asp:Button ID="btnModifier" runat="server" Text="Modifier" OnClick="btnModifier_Click" />
      	<asp:Panel ID="pnlEditionInscription" runat="server" Enabled="False">
			<asp:CheckBoxList ID="cblInscriptions" runat="server">
			</asp:CheckBoxList>
			<asp:Button ID="btnSuprimerSelection" runat="server" OnClick="btnSuprimerSelection_Click" Text="Suprimer la sélection" />
		  </asp:Panel>
		  <br />
		  <asp:Label ID="lblInformations" runat="server" Text="Informations :"></asp:Label>
		  <asp:Panel ID="pnlInformations" runat="server">
			  <asp:Label ID="lblPrenom" runat="server" Text="Prénom :"></asp:Label>
			  <asp:TextBox ID="txtbPrenom" runat="server"></asp:TextBox>
			  <br />
			  <asp:Label ID="lblNom" runat="server" Text="Nom :"></asp:Label>
			  <asp:TextBox ID="txtbNom" runat="server"></asp:TextBox>
			  <br />
			  <asp:Label ID="lblNoMembre" runat="server" Text="Numéro de membre :"></asp:Label>
			  <asp:TextBox ID="txtbNoMembre" runat="server"></asp:TextBox>
		  </asp:Panel>
		  <asp:Button ID="btnConfirmer" runat="server" Text="Confirmer" />
		  <asp:Button ID="btnAnnuler" runat="server" Text="Annuler" />
      </asp:Panel>
    </form>
</body>
</html>
