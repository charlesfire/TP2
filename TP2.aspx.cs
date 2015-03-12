using System;
using System.Collections.Generic;

public partial class TP2 : System.Web.UI.Page
{
	#region Charles
	private DateTime d1 = new DateTime(2015, 3, 14);
	private DateTime d2 = new DateTime(2015, 3, 15);
	private DateTime d3 = new DateTime(2015, 3, 16);

	private SortedDictionary<string, int> test = new SortedDictionary<string,int>();

	protected void Page_Load(object sender, EventArgs e)
	{
		test.Add("League of Legends : Summoner's Rift", 3);
		test.Add("League of Legends : Crystal Scar", 2);

		if (ddlJeu.Items.Count == 0)
		{
			foreach (string jeu in test.Keys)
			{
				ddlJeu.Items.Add(jeu);
			}
		}
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

		if (e.Day.Date.ToShortDateString() == d1.ToShortDateString() ||
			e.Day.Date.ToShortDateString() == d2.ToShortDateString() ||
			e.Day.Date.ToShortDateString() == d3.ToShortDateString())
		{
			e.Day.IsSelectable = true;
		}
	}

	protected void calendrierEvenement_SelectionChanged(object sender, EventArgs e)
	{
		pnlEvenement.Enabled = true;
	}
	#endregion

	#region Vincent

	#endregion
}