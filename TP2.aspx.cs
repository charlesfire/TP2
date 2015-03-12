using System;
using System.Collections.Generic;

public partial class TP2 : System.Web.UI.Page
{
	#region Charles

	private SortedDictionary<DateTime, string> datesEvenement = new SortedDictionary<DateTime,string>();

	private SortedDictionary<string, int> planchersParJeu = new SortedDictionary<string,int>();

	protected void Page_Load(object sender, EventArgs e)
	{
		datesEvenement.Add(new DateTime(2015, 3, 14), "FragFest Québec");
		datesEvenement.Add(new DateTime(2015, 3, 15), "Stream Open");
		datesEvenement.Add(new DateTime(2015, 3, 16), "Stream Open");

		planchersParJeu.Add("League of Legends : Summoner's Rift", 3);
		planchersParJeu.Add("League of Legends : Crystal Scar", 2);

		if (ddlJeu.Items.Count == 0)
		{
			foreach (string jeu in planchersParJeu.Keys)
			{
				ddlJeu.Items.Add(jeu);
			}
		}

		MettreAJourPlancher();
	}

	protected void btnModifier_Click(object sender, EventArgs e)
	{
		pnlEditionInscription.Enabled = !pnlEditionInscription.Enabled;
		if (pnlEditionInscription.Enabled)
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
			cblInscriptions.Items.Remove(cblInscriptions.SelectedItem);
		}
		btnModifier.Text = "Modifier";
		pnlEditionInscription.Enabled = false;
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
		pnlEvenement.Enabled = true;

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
	#endregion

	#region Vincent

	#endregion
}