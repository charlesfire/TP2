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