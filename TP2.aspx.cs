using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

public partial class TP2 : System.Web.UI.Page
{
	#region Charles

	private SortedDictionary<DateTime, string> datesEvenement = new SortedDictionary<DateTime,string>();

	private SortedDictionary<string, int> planchersParJeu = new SortedDictionary<string,int>();

	private static List<Inscription> inscriptions = new List<Inscription>();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (datesEvenement.Count == 0)
		{
			datesEvenement.Add(new DateTime(2015, 3, 14), "FragFest Québec");
			datesEvenement.Add(new DateTime(2015, 3, 15), "Stream Open");
			datesEvenement.Add(new DateTime(2015, 3, 16), "Stream Open");

			planchersParJeu.Add("League of Legends : Summoner's Rift", 3);
			planchersParJeu.Add("League of Legends : Crystal Scar", 2);
		}

		if (ddlJeu.Items.Count == 0)
		{
			foreach (string jeu in planchersParJeu.Keys)
			{
				ddlJeu.Items.Add(jeu);
			}

			GenererHeuresDisponibles();

			MettreAJourPlancher();
		}

		if (inscriptions.Count != cblInscriptions.Items.Count)
		{
			cblInscriptions.Items.Clear();
			foreach (Inscription inscription in inscriptions)
			{
				cblInscriptions.Items.Add(inscription.ToString());
			}
			pnlEditionInscription.Visible = true;
		}

		if (!Page.IsPostBack)
		{
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

	protected void btnModifier_Click(object sender, EventArgs e)
	{
		cblInscriptions.Enabled = !cblInscriptions.Enabled;
		btnSuprimerSelection.Visible = cblInscriptions.Enabled;
		if (cblInscriptions.Enabled)
		{
			btnModifier.Text = "Annuler";
		}
		else
		{
			btnModifier.Text = "Modifier";
		}
	}

	protected void btnSuprimerSelection_Click(object sender, EventArgs e)
	{
		while (cblInscriptions.SelectedItem != null)
		{
			inscriptions.RemoveAt(cblInscriptions.SelectedIndex);
			Console.WriteLine(inscriptions.ToString());
			cblInscriptions.Items.RemoveAt(cblInscriptions.SelectedIndex);
		}
		btnModifier.Text = "Modifier";
		cblInscriptions.Enabled = false;
		btnSuprimerSelection.Visible = false;
		if (inscriptions.Count == 0)
		{
			pnlEditionInscription.Visible = false;
		}
	}

	protected void calendrierEvenement_DayRender(object sender, System.Web.UI.WebControls.DayRenderEventArgs e)
	{
		e.Day.IsSelectable = false;

		foreach (DateTime date in datesEvenement.Keys)
		{
			if (e.Day.Date.ToShortDateString() == date.ToShortDateString())
			{
				e.Day.IsSelectable = true;
			}
		}
	}

	protected void calendrierEvenement_SelectionChanged(object sender, EventArgs e)
	{
		pnlEvenement.Visible = true;

		string nomEvenement = "";
		if (datesEvenement.TryGetValue(calendrierEvenement.SelectedDate, out nomEvenement))
		{
			lblEvenement.Text = nomEvenement;
		}
	}

	protected void ddlJeu_SelectedIndexChanged(object sender, EventArgs e)
	{
		MettreAJourPlancher();
	}

	private void MettreAJourPlancher()
	{
		ddlPlancher.Items.Clear();

		int nombreDePlancher = 0;
		if (planchersParJeu.TryGetValue(ddlJeu.SelectedValue, out nombreDePlancher))
		{
			for (int i = 1; i <= nombreDePlancher; i++)
			{
				ddlPlancher.Items.Add(i.ToString());
			}
		}
	}

	private void GenererHeuresDisponibles()
	{
		ddlHeure.Items.Clear();
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

	protected void btnAjouter_Click(object sender, EventArgs e)
	{
		Page.Validate("validerAjoutInscription");
		if (Page.IsValid)
		{
			Inscription nouvelleInscription = new Inscription();

			nouvelleInscription.SetEvenement(lblEvenement.Text);
			nouvelleInscription.SetJeu(ddlJeu.SelectedValue);
			nouvelleInscription.SetPlancher(int.Parse(ddlPlancher.SelectedValue));

			DateTime date = new DateTime();
			if (DateTime.TryParse(ddlHeure.SelectedValue, out date))
			{
				nouvelleInscription.SetDate(new DateTime(calendrierEvenement.SelectedDate.Year, calendrierEvenement.SelectedDate.Month,
															calendrierEvenement.SelectedDate.Day, date.Hour, date.Minute, date.Second));
			}
			cblInscriptions.Items.Add(nouvelleInscription.ToString());

			inscriptions.Add(nouvelleInscription);
			pnlEditionInscription.Visible = true;
		}
	}

	protected void btnAnnuler_Click(object sender, EventArgs e)
	{
		inscriptions.Clear();
		Session.Clear();
		Response.Redirect("TP2.aspx");
	}

	protected void btnConfirmer_Click(object sender, EventArgs e)
	{
		Page.Validate("validerDocument");
		if (Page.IsValid)
		{
			Session["Nom"] = txtbNom.Text;
			Session["Prénom"] = txtbPrenom.Text;
			Session["Numéro"] = txtbNoMembre.Text;
			Session["Inscriptions"] = inscriptions;
			Response.Redirect("Resume.aspx");
		}
	}

	protected void cvNumero_ServerValidate(object source, ServerValidateEventArgs args)
	{
		args.IsValid = false;
		if (txtbPrenom.Text.Length > 0 && txtbNom.Text.Length > 0 && args.Value.Length == 10)
		{
			Regex regexp = new Regex(txtbPrenom.Text.Substring(0, 1) + txtbNom.Text.Substring(0, 1) + "\\d{8}", RegexOptions.IgnoreCase);
			if (regexp.IsMatch(args.Value))
			{
				args.IsValid = true;
			}
		}
	}

	protected void cvNbMaxInscriptionParEvenement_ServerValidate(object source, ServerValidateEventArgs args)
	{
		string evenements = "";

		for (int i = 0; i < inscriptions.Count; i++)
		{
			evenements += inscriptions[i].GetEvenement();
		}

		args.IsValid = true;
		Regex regexp = new Regex(lblEvenement.Text);
		if (regexp.Matches(evenements).Count >= 6)
		{
			args.IsValid = false;
		}
	}

	protected void cvNbMinimumMatch_ServerValidate(object source, ServerValidateEventArgs args)
	{
		args.IsValid = inscriptions.Count >= 1;
	}
	#endregion

	#region Vincent

	#endregion
}