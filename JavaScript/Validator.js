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
	var cblInscriptions = document.getElementById("cblInscriptions");
	var inscriptions = cblInscriptions.getElementsByTagName("LABEL");
	var evenementSelectionne = document.getElementById("lblEvenement");
	var evenements = "";

	for (var i = 0; i < inscriptions.length; i++)
	{
		evenements += inscriptions[i].innerHTML.split(" | ")[0];
	}

	args.IsValid = true;
	if (evenements.match(new RegExp(evenementSelectionne.innerHTML, "g")).length >= 6)
	{
		args.IsValid = false;
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