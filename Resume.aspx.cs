﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Resume : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		lblPrenom.Text = (string)Session["Prénom"];
		lblNom.Text = (string)Session["Nom"];
		lblNumero.Text = lblPrenom.Text + " " + lblNom.Text + "<br />#" + (string)Session["Numéro"];
		lblDate.Text = DateTime.Now.ToLongDateString() + " à " + DateTime.Now.ToShortTimeString();

		List<Inscription> inscriptions = (List<Inscription>)Session["Inscriptions"];
		if (inscriptions != null)
		{
			foreach (Inscription inscription in inscriptions)
			{
				TableRow nouvelleLigne = new TableRow();

				TableCell nouvelleCellule = new TableCell();
				nouvelleCellule.Text = inscription.GetEvenement();
				nouvelleLigne.Cells.Add(nouvelleCellule);

				nouvelleCellule = new TableCell();
				nouvelleCellule.Text = inscription.GetJeu();
				nouvelleLigne.Cells.Add(nouvelleCellule);

				nouvelleCellule = new TableCell();
				nouvelleCellule.Text = "#" + inscription.GetPlancher();
				nouvelleLigne.Cells.Add(nouvelleCellule);

				nouvelleCellule = new TableCell();
				nouvelleCellule.Text = inscription.GetDate().ToLongDateString();
				nouvelleLigne.Cells.Add(nouvelleCellule);

				nouvelleCellule = new TableCell();
				nouvelleCellule.Text = inscription.GetDate().ToShortTimeString();
				nouvelleLigne.Cells.Add(nouvelleCellule);

				tbInscriptions.Rows.Add(nouvelleLigne);
			}
		}
	}

	protected void btnRetour_Click(object sender, EventArgs e)
	{
		Response.Redirect("TP2.aspx");
	}
}