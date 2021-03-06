﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

public partial class TP2 : System.Web.UI.Page
{
	/// <summary>
	/// Variable contenant une liste de dates associées à des évènements
	/// </summary>
	private SortedDictionary<DateTime, string> datesEvenement = new SortedDictionary<DateTime,string>();

	/// <summary>
	/// Variable contenant une liste de nombres de plancher associées à des jeux
	/// </summary>
	private SortedDictionary<string, int> planchersParJeu = new SortedDictionary<string,int>();

	/// <summary>
	/// Variable contenant la liste des inscriptions
	/// </summary>
	private static List<Inscription> inscriptions = new List<Inscription>();


	/// <summary>
	/// Fonction appelée lors du chargement/rechargement/postback de la page
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		// Si le conteneur associatif des dates/évènements est vide...
		if (datesEvenement.Count == 0)
		{
			// On le remplit
			datesEvenement.Add(new DateTime(2015, 3, 14), "Stream Open");
			datesEvenement.Add(new DateTime(2015, 3, 15), "Stream Open");
			datesEvenement.Add(new DateTime(2015, 3, 22), "FragFest Québec");
			datesEvenement.Add(new DateTime(2015, 3, 28), "Steam Ultimate Tournament");
		}

		// Si le conteneur associatif des planchers/jeux est vide...
		if (planchersParJeu.Count == 0)
		{
			// On le remplit			
			planchersParJeu.Add("League of Legends : Summoner's Rift", 6);
			planchersParJeu.Add("League of Legends : Crystal Scar", 2);
			planchersParJeu.Add("League of Legends : Howling Abyss", 4);
			planchersParJeu.Add("Minecraft : Hunger Games", 3);
			planchersParJeu.Add("DOTA 2", 5);
			planchersParJeu.Add("Team Fortress 2", 4);
			planchersParJeu.Add("Counter-Strike", 3);
			planchersParJeu.Add("Quake III", 2);
			planchersParJeu.Add("Minecraft Artistic Challenge", 1);
		}

		// Si le contrôle permettant de sélectionner un jeu est vide...
		if (ddlJeu.Items.Count == 0)
		{
			// On le remplit de tous les jeux disponibles
			foreach (string jeu in planchersParJeu.Keys)
			{
				ddlJeu.Items.Add(jeu);
			}

			// On génère les heures de matchs
			GenererHeuresDisponibles();

			// On met à jours les planchers disponibles
			MettreAJourPlancher();
		}

		// Si le nombre d'inscription réel est différent de celui afficher...
		if (inscriptions.Count != cblInscriptions.Items.Count)
		{
			// On efface les inscriptions présentes
			cblInscriptions.Items.Clear();

			// On génère à nouveaux les inscription à afficher
			foreach (Inscription inscription in inscriptions)
			{
				cblInscriptions.Items.Add(inscription.ToString());
			}

			// On affiche les inscriptions
			pnlEditionInscription.Visible = true;
		}

		// Si la page n'est pas un postback
		if (!Page.IsPostBack)
		{
			// On récupère les informations déjà rentré par l'utilisateur
			if (txtbPrenom.Text == "" && Session["Prénom"] != null)
			{
				txtbPrenom.Text = (string)Session["Prénom"];
			}

			if (txtbNom.Text == "" && Session["Nom"] != null)
			{
				txtbNom.Text = (string)Session["Nom"];
			}

			if (txtbNoMembre.Text == "" && Session["Numéro"] != null)
			{
				txtbNoMembre.Text = (string)Session["Numéro"];
			}
		}
	}

	/// <summary>
	/// Fonction appelée lors d'un clique sur le bouton modifier
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnModifier_Click(object sender, EventArgs e)
	{
		// On inverse la possibilité de cocher les cases à cocher
		cblInscriptions.Enabled = !cblInscriptions.Enabled;

		// On affiche ou on cache le bouton de supression
		btnSuprimerSelection.Visible = cblInscriptions.Enabled;

		// Si on est entrain de modifier les inscriptions...
		if (cblInscriptions.Enabled)
		{
			// On change le texte du bouton "Modifier"
			btnModifier.Text = "Annuler";
		}
		else
		{
			// On change le texte du bouton "Annuler"
			btnModifier.Text = "Modifier";
		}
	}

	/// <summary>
	/// Fonction appelée lors d'un clique sur le bouton suprimer
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnSuprimerSelection_Click(object sender, EventArgs e)
	{
		// Tant qu'il reste un élément coché...
		while (cblInscriptions.SelectedItem != null)
		{
			// On le suprime
			inscriptions.RemoveAt(cblInscriptions.SelectedIndex);

			// on suprime l'inscription correspondante
			cblInscriptions.Items.RemoveAt(cblInscriptions.SelectedIndex);
		}

		// On remmet le bouton "Modifier" à son état normal
		btnModifier.Text = "Modifier";

		// On désactive les cases à cocher
		cblInscriptions.Enabled = false;

		// On cache le bouton de suppression
		btnSuprimerSelection.Visible = false;

		// S'il ne reste plus aucune inscription...
		if (inscriptions.Count == 0)
		{
			// On cache l'espace des inscriptions
			pnlEditionInscription.Visible = false;
		}
	}

	/// <summary>
	/// Fonction appelée lors du rendu d'une journée du calendrier
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void calendrierEvenement_DayRender(object sender, System.Web.UI.WebControls.DayRenderEventArgs e)
	{
		// Pour chaque journée ou il y a un événement...
		foreach (DateTime date in datesEvenement.Keys)
		{
			// On rend la journée entrain d'être rendue sélectionnable si elle correspond à la journée qu'y a un évènement
			e.Day.IsSelectable = e.Day.Date.ToShortDateString() == date.ToShortDateString();
		}
	}

	/// <summary>
	/// Fonction appelée lorsque l'utilisateur sélectionne une date du calendrier
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void calendrierEvenement_SelectionChanged(object sender, EventArgs e)
	{
		// On rend les contrôles permettant d'ajouter une inscription visible
		pnlEvenement.Visible = true;

		// On récupère l'évènement associé à la date sélectionné
		string nomEvenement = "";
		if (datesEvenement.TryGetValue(calendrierEvenement.SelectedDate, out nomEvenement))
		{
			// On affiche l'évènement sélectionné
			lblEvenement.Text = nomEvenement;
		}
	}

	/// <summary>
	/// Fonction appelée lorsque l'utilisateur sélectionne un jeu
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void ddlJeu_SelectedIndexChanged(object sender, EventArgs e)
	{
		// On met à jours les planchers disponibles
		MettreAJourPlancher();
	}

	/// <summary>
	/// Fonction appelée lorsque l'utilisateur clique sur le bouton "Ajouter"
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnAjouter_Click(object sender, EventArgs e)
	{
		// On vérifie que les entrés de l'utilisateur sont valides
		Page.Validate("validerAjoutInscription");

		// Si les entrés de l'utilisateur sont valide...
		if (Page.IsValid)
		{
			// On ajoute une nouvelle inscription
			Inscription nouvelleInscription = new Inscription();

			nouvelleInscription.SetEvenement(lblEvenement.Text);
			nouvelleInscription.SetJeu(ddlJeu.SelectedValue);
			nouvelleInscription.SetPlancher(int.Parse(ddlPlancher.SelectedValue));

			// On génère la date et l'heure du match
			DateTime date = new DateTime();
			if (DateTime.TryParse(ddlHeure.SelectedValue, out date))
			{
				nouvelleInscription.SetDate(new DateTime(calendrierEvenement.SelectedDate.Year, calendrierEvenement.SelectedDate.Month,
															calendrierEvenement.SelectedDate.Day, date.Hour, date.Minute, date.Second));
			}

			// On ajoute visuellement à la page l'inscription
			cblInscriptions.Items.Add(nouvelleInscription.ToString());

			// On ajout l'inscription à la liste des inscriptions
			inscriptions.Add(nouvelleInscription);

			// On rend les inscriptions visibles
			pnlEditionInscription.Visible = true;
		}
	}

	/// <summary>
	/// Fonction appelée lorsque l'utilisateur clique sur le bouton "Annuler"
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnAnnuler_Click(object sender, EventArgs e)
	{
		// On efface les inscriptions
		inscriptions.Clear();

		// On efface les variables de session
		Session.Clear();

		// On recharge la page pour effacer tout le reste
		Response.Redirect("TP2.aspx");
	}

	/// <summary>
	/// Fonction appelée lorsque l'utilisateur clique sur le bouton "Comfirmer"
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnConfirmer_Click(object sender, EventArgs e)
	{
		// On vérifie que les entrés de l'utilisateur sont valides
		Page.Validate("validerDocument");

		// Si les entrés sont valide...
		if (Page.IsValid)
		{
			// On sauvegarde les informations pertinentes dans des variables de session
			Session["Nom"] = txtbNom.Text;
			Session["Prénom"] = txtbPrenom.Text;
			Session["Numéro"] = txtbNoMembre.Text;
			Session["Inscriptions"] = inscriptions;

			// On charge la page de résumé
			Response.Redirect("Resume.aspx");
		}
	}

	/// <summary>
	/// Fonction appelée lors de la validation du numéro du membre
	/// </summary>
	/// <param name="source"></param>
	/// <param name="args"></param>
	protected void cvNumero_ServerValidate(object source, ServerValidateEventArgs args)
	{
		// On considère que le numéro de membre n'est pas valide à la base
		args.IsValid = false;

		// Si l'utilisateur a rentré un nom et un prénom et que le numéro de membre est de la bonne longeur...
		if (txtbPrenom.Text.Length > 0 && txtbNom.Text.Length > 0 && args.Value.Length == 10)
		{
			// On génère une expression régulière pour vérifier si le numéro est valide
			Regex regexp = new Regex(txtbPrenom.Text.Substring(0, 1) + txtbNom.Text.Substring(0, 1) + "\\d{8}", RegexOptions.IgnoreCase);

			// Si le numéro est valide...
			if (regexp.IsMatch(args.Value))
			{
				args.IsValid = true;
			}
		}
	}

	/// <summary>
	/// Fonction appelée lors de la validation du nombre maximal d'inscription par évènement
	/// </summary>
	/// <param name="source"></param>
	/// <param name="args"></param>
	protected void cvNbMaxInscriptionsParEvenement_ServerValidate(object source, ServerValidateEventArgs args)
	{
		// On considère qu'il n'y a pas plus de 6 match par évènement à la base
		args.IsValid = true;

		// Variable contenant l'ensemble des évènements sous forme de chaine de caractère
		string evenements = "";

		// On remplit la variable avec le nom de tous les évènements aux quels l'utilisateur a souscrit
		for (int i = 0; i < inscriptions.Count; i++)
		{
			evenements += inscriptions[i].GetEvenement();
		}

		// On génère une expression régulière pour compter le nombre de fois que l'utilisateur a souscrit à
		//   un match faisant partit du même évènement
		Regex regexp = new Regex(lblEvenement.Text);

		// Si l'utilisateur a déjà souscrit à 6 matchs pour cet évènement...
		if (regexp.Matches(evenements).Count >= 6)
		{
			// Il ne peut pas s'inscrire à un match de plus pour cet évènement
			args.IsValid = false;
		}
	}

	/// <summary>
	/// Fonction appelée lors de la validation du nombre minimum d'inscription à des matchs
	/// </summary>
	/// <param name="source"></param>
	/// <param name="args"></param>
	protected void cvNbMinimumMatch_ServerValidate(object source, ServerValidateEventArgs args)
	{
		// Si l'utilisateur n'as pas sourcrit à au moins un match, il ne peut pas continuer
		args.IsValid = inscriptions.Count >= 1;
	}

	/// <summary>
	/// Fonction appelée lors de la validation vérifiant si l'utilisateur ne s'est pas inscrit
	///    deux fois à la même heure le même jour
	/// </summary>
	/// <param name="source"></param>
	/// <param name="args"></param>
	protected void cvInscriptionsMemeHeure_ServerValidate(object source, ServerValidateEventArgs args)
	{
		// On considère à la base qu'il ne s'est pas inscrit deux fois à la même heure le même jour
		args.IsValid = true;

		// On récupère la date et l'heure à laquelle l'utilisateur souhaite ajouter un match
		DateTime date = new DateTime();
		if (DateTime.TryParse(ddlHeure.SelectedValue, out date))
		{
			date = new DateTime(calendrierEvenement.SelectedDate.Year, calendrierEvenement.SelectedDate.Month,
														calendrierEvenement.SelectedDate.Day, date.Hour, date.Minute, date.Second);

			// Pour chaque inscription...
			for (int i = 0; i < inscriptions.Count; i ++)
			{
				// Si l'inscription est à la même date
				if(inscriptions[i].GetDate() == date)
				{
					// L'utilisateur ne peut pas s'inscrire (à moins qu'il puisse se diviser en deux XD)
					args.IsValid = false;
				}
			}
		}
	}

	/// <summary>
	/// Fonction appelée lors de la validation vérifiant si l'utilisateur s'est déjà inscrit à plus
	///		de 3 match par plancher par jour
	/// </summary>
	/// <param name="source"></param>
	/// <param name="args"></param>
	protected void cvNbMaxInscriptionsParPlancher_ServerValidate(object source, ServerValidateEventArgs args)
	{
		// On considère à la base qu'il ne s'est pas inscrit à plus de 3 match par plancher par évènement
		args.IsValid = true;

		// On récupère la date à laquelle il souhaite ajouter une inscription
		DateTime date = new DateTime();
		if (DateTime.TryParse(ddlHeure.SelectedValue, out date))
		{
			date = new DateTime(calendrierEvenement.SelectedDate.Year, calendrierEvenement.SelectedDate.Month,
														calendrierEvenement.SelectedDate.Day, date.Hour, date.Minute, date.Second);

			// On récupère le numéro du plancher sur lequel il souhaite s'inscrire
			int numeroPlancher = int.Parse(ddlPlancher.SelectedValue);

			// Le nombre d'incription qu'il as pour le plancher sur lequel il veut ajouter un match
			int nbInscription = 0;

			// Pour chaque inscription...
			for (int i = 0; i < inscriptions.Count; i++)
			{
				// Si elles sont le même jour et sur le même plancher...
				if (inscriptions[i].GetDate().Date == date.Date && inscriptions[i].GetPlancher() == numeroPlancher)
				{
					// On augmente le nombre d'incription qu'il as pour le plancher sur lequel il veut ajouter un match
					nbInscription++;
				}
			}

			// S'il a déjà 3 inscriptions pour le plancher sur lequel il veut ajouter un match...
			if (nbInscription >= 3)
			{
				// Il ne peut pas s'inscrire
				args.IsValid = false;
			}
		}
	}

	/// <summary>
	/// Met à jours le nombre de plancher disponible pour le jeu sélectionné
	/// </summary>
	private void MettreAJourPlancher()
	{
		// On efface le nombre de plancher disponible
		ddlPlancher.Items.Clear();

		// On récupère le nombre de plancher disponible
		int nombreDePlancher = 0;
		if (planchersParJeu.TryGetValue(ddlJeu.SelectedValue, out nombreDePlancher))
		{
			// Pour chaque plancher disponible...
			for (int i = 1; i <= nombreDePlancher; i++)
			{
				// On ajoute la posibilité de sélectionner ce plancher
				ddlPlancher.Items.Add(i.ToString());
			}
		}
	}

	/// <summary>
	/// Génère les heures disponibles
	/// </summary>
	private void GenererHeuresDisponibles()
	{
		// On efface les heures disponibles
		ddlHeure.Items.Clear();

		// On ajoute les heures disponibles
		DateTime heureDisponible = new DateTime(1, 1, 1, 13, 0, 0);
		heureDisponible.AddHours(13);
		ddlHeure.Items.Add(heureDisponible.ToShortTimeString());
		heureDisponible = heureDisponible.AddHours(2);
		ddlHeure.Items.Add(heureDisponible.ToShortTimeString());
		heureDisponible = heureDisponible.AddHours(2);
		ddlHeure.Items.Add(heureDisponible.ToShortTimeString());
		heureDisponible = heureDisponible.AddHours(2);
		ddlHeure.Items.Add(heureDisponible.ToShortTimeString());
		heureDisponible = heureDisponible.AddHours(2);
		ddlHeure.Items.Add(heureDisponible.ToShortTimeString());
	}
}