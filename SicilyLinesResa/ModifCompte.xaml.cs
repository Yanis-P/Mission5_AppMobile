using Newtonsoft.Json;

namespace SicilyLinesResa;

public partial class ModifCompte : ContentPage
{
    private Client? _clientData = null;

    public ModifCompte()
	{

        InitializeComponent();
	}

    async private void Retour_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    async private void Enregistrer_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (BindingContext is Client client)
            {
                _clientData = new Client(client.Id, client.Nom, client.Mdp, eA.Text, eCP.Text, eV.Text);
            }

            if (_clientData == null)
            {
                await DisplayAlert("Erreur", "Impossible de récupérer les informations du client.", "OK");
                return;
            }

            HttpClient clientHttp = new HttpClient();
            var restUrl = "http://localhost:5044/Profile";

            // Sérialiser l'objet en JSON
            var json = JsonConvert.SerializeObject(new
            {
                id = _clientData.Id,
                adresse = _clientData.Adresse,
                codePostal = _clientData.CodePostal,
                ville = _clientData.Ville

            });
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Envoyer la requête PUT (ou PostAsync pour créer)
            HttpResponseMessage response = await clientHttp.PostAsync(restUrl, content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Succès", "Profil mis à jour avec succès", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Erreur", Convert.ToString(content), "OK");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}