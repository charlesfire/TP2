using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Resume : System.Web.UI.Page
{
	/// <summary>
	/// Événement produit lors du chargement de la page
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		// On affiche le nom/prénom/numéro de participant du membre ayant souscrit à des matchs
		lblPrenom.Text = (string)Session["Prénom"];
		lblNom.Text = (string)Session["Nom"];
		lblNumero.Text = lblPrenom.Text + " " + lblNom.Text + "<br />#" + (string)Session["Numéro"];

		// On affiche la date et l'heure actuelle
		lblDate.Text = DateTime.Now.ToLongDateString() + " à " + DateTime.Now.ToShortTimeString();

		// On récupère les incriptions
		List<Inscription> inscriptions = (List<Inscription>)Session["Inscriptions"];

		// Si les incriptions existent...
		if (inscriptions != null)
		{
			// on parcours les inscriptions
			foreach (Inscription inscription in inscriptions)
			{
				// On ajoute une ligne au tableau
				TableRow nouvelleLigne = new TableRow();

				// On ajoute la cellule de l'évènement
				TableCell nouvelleCellule = new TableCell();
				nouvelleCellule.Text = inscription.GetEvenement();
				nouvelleLigne.Cells.Add(nouvelleCellule);

				// On ajoute la cellule du jeu
				nouvelleCellule = new TableCell();
				nouvelleCellule.Text = inscription.GetJeu();
				nouvelleLigne.Cells.Add(nouvelleCellule);

				// On ajoute la cellule du plancher
				nouvelleCellule = new TableCell();
				nouvelleCellule.Text = "#" + inscription.GetPlancher();
				nouvelleLigne.Cells.Add(nouvelleCellule);

				// On ajoute la cellule de la date
				nouvelleCellule = new TableCell();
				nouvelleCellule.Text = inscription.GetDate().ToLongDateString();
				nouvelleLigne.Cells.Add(nouvelleCellule);

				// On ajoute la cellule de l'heure
				nouvelleCellule = new TableCell();
				nouvelleCellule.Text = inscription.GetDate().ToShortTimeString();
				nouvelleLigne.Cells.Add(nouvelleCellule);

				// On ajoute au tableau la nouvelle ligne
				tbInscriptions.Rows.Add(nouvelleLigne);
			}
		}
	}

	/// <summary>
	/// Événement produit lors d'un clique sur le boutton "Retour"
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnRetour_Click(object sender, EventArgs e)
	{
		// On retourne à la page principale
		Response.Redirect("TP2.aspx");
	}
}