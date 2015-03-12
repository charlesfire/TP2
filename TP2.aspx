<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TP2.aspx.cs" Inherits="TP2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <h1>YOLO</h1>
    </div>
      <p>
        Explication sur la page</p>
      <asp:Calendar ID="calendrierEvenement" runat="server"></asp:Calendar>
      <asp:Panel ID="pnlEvenement" runat="server">
        <asp:Label ID="lblJeu" runat="server" Text="Jeu : "></asp:Label>
        <asp:DropDownList ID="ddlJeu" runat="server">
          <asp:ListItem>League of Legends</asp:ListItem>
          <asp:ListItem>Warcraft III</asp:ListItem>
          <asp:ListItem>Starcraft II</asp:ListItem>
          <asp:ListItem>Super Smash Bros Brawl</asp:ListItem>
          <asp:ListItem>Minecraft : Hunger Games</asp:ListItem>
          <asp:ListItem>Minecraft : CTF</asp:ListItem>
          <asp:ListItem>Dota 2</asp:ListItem>
          <asp:ListItem>Half-Life 2</asp:ListItem>
          <asp:ListItem>Team Fortress II</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="lblPlancher" runat="server" Text="Plancher : "></asp:Label>
        <asp:DropDownList ID="ddlPlancher" runat="server">
        </asp:DropDownList>
        <asp:Label ID="lblHeure" runat="server" Text="Heure : "></asp:Label>
        <asp:DropDownList ID="ddlHeure" runat="server">
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
			  <asp:TextBox ID="txtbPrenom0" runat="server"></asp:TextBox>
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
