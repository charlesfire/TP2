using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Inscription
/// </summary>
public class Inscription
{
	private string evenement = "";
	private string jeu = "";
	private int plancher = -1;
	private DateTime heure = new DateTime(1, 1, 1);

	public Inscription()
	{
		evenement = "";
		jeu = "";
		plancher = -1;
		heure = new DateTime(1, 1, 1);
	}

	public string GetEvenement()
	{
		return evenement;
	}

	public void SetEvenement(string evenement)
	{
		this.evenement = evenement;
	}

	public string GetJeu()
	{
		return jeu;
	}

	public void SetJeu(string jeu)
	{
		this.jeu = jeu;
	}

	public int GetPlancher()
	{
		return plancher;
	}

	public void SetPlancher(int plancher)
	{
		this.plancher = plancher;
	}

	public DateTime GetHeure()
	{
		return heure;
	}

	public void SetHeure(DateTime heure)
	{
		this.heure = heure;
	}

	public override string ToString()
	{
		return "Événement : " + evenement + " | Jeu : " + jeu + " | Plancher #" + plancher + " | Date : " + heure.ToString();
	}
}