using Newtonsoft.Json;

namespace SicilyLinesResa;

public partial class ModifCompte : ContentPage
{
    private Client? _clientData = null;

    public ModifCompte(Client client)
    {
        InitializeComponent();
        _clientData = client;
        BindingContext = client;
        //DisplayAlert("Info", $"Client chargé : {client.ToString()}", "OK");
    }

    async private void Retour_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }


    async private void Enregistrer_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (_clientData == null)
            {
                await DisplayAlert("Erreur", "Impossible de récupérer les informations du client.", "OK");
                return;
            }

            _clientData.Adresse = eA.Text;
            _clientData.CodePostal = eCP.Text;
            _clientData.Ville = eV.Text;

            HttpClient clientHttp = new HttpClient();
            var restUrl = $"http://localhost:5044/Profile?id={_clientData.Id}&adresse={_clientData.Adresse}&codePostal={_clientData.CodePostal}&ville={_clientData.Ville}";

            HttpResponseMessage response = await clientHttp.PutAsync(restUrl, null);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Succès", "Profil mis à jour avec succès", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Erreur", errorMessage, "OK");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}