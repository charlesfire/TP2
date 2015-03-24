function validerNumeroMembre(source, args)
{
	var prenom = document.getElementById("txtbPrenom").value;
	var nom = document.getElementById("txtbNom").value;

	args.IsValid = false;
	if (prenom.length > 0 && nom.length > 0 && args.Value.length == 10)
	{
		var regexp = new RegExp(prenom[0] + nom[0] + "\\d{8}", "i");

		if (args.Value.search(regexp) != -1)
		{
			args.IsValid = true;
		}
	}
}

function validerNbMaxIncriptionParEvenement(source, args)
{
	args.IsValid = true;
	var cblInscriptions = document.getElementById("cblInscriptions");
	if (cblInscriptions)
	{
		var inscriptions = cblInscriptions.getElementsByTagName("LABEL");
		var evenementSelectionne = document.getElementById("lblEvenement");
		var evenements = "";

		for (var i = 0; i < inscriptions.length; i++) {
			evenements += inscriptions[i].innerHTML.split(" | ")[0];
		}

		if (evenements.match(new RegExp(evenementSelectionne.innerHTML, "g")).length >= 6) {
			args.IsValid = false;
		}
	}
}

function validerNbMinInscription(source, args)
{
	var cblInscriptions = document.getElementById("cblInscriptions");
	args.IsValid = false;
	if (cblInscriptions)
	{
		var inscriptions = cblInscriptions.getElementsByTagName("LABEL");

		args.IsValid = inscriptions.length >= 1;
	}
}

function validerInscriptionsMemeHeure(source, args)
{
	args.IsValid = true;
	var cblInscriptions = document.getElementById("cblInscriptions");
	if (cblInscriptions)
	{
		var date = $("#calendrierEvenement > tbody > tr:nth-child(1) > td > table > tbody > tr > td")[0].innerHTML;
		date = $("#calendrierEvenement a[style*='color:White']")[0].innerHTML + " " + date;
		var heure = document.getElementById("ddlHeure").value;
		var inscriptions = cblInscriptions.getElementsByTagName("LABEL");
		var evenements = "";

		for (var i = 0; i < inscriptions.length; i++)
		{
			evenements += inscriptions[i].innerHTML;
		}

		var dateEtHeure = "Date : " + date + " \\| Heure : " + heure;
		if (evenements.match(new RegExp(dateEtHeure)))
		{
			args.IsValid = false;
		}
	}
}