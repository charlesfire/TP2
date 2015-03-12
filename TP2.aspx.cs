using System;

public partial class TP2 : System.Web.UI.Page
{
	#region Charles
	protected void Page_Load(object sender, EventArgs e)
	{
	  
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
	#endregion

	#region Vincent

	#endregion
}