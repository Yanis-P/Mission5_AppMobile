using Newtonsoft.Json;

namespace SicilyLinesResa;

public partial class ComptePage : ContentPage
{
    // Stocker le client dans un champ pour y accéder depuis le bouton
    private Client? _currentClient;

    public ComptePage()
    {
        InitializeComponent();
        loadCompteFromAPI();
    }

    public async void loadCompteFromAPI()
    {
        try
        {
            HttpClient client = new HttpClient();
            var restUrl = "http://localhost:5044/Profile";
            client.BaseAddress = new Uri(restUrl);
            HttpResponseMessage response = await client.GetAsync(restUrl);
            var content = await response.Content.ReadAsStringAsync();

            // recherche avec le login du client pour trouver le client correspondant
            if (BindingContext is LoginInfo loginInfo)
            {
                var items = JsonConvert.DeserializeObject<List<Client>>(content);

                // Filtrer le client correspondant au loginInfo
                _currentClient = items?.FirstOrDefault(c => c.Nom == loginInfo.Login);

                // Mettre à jour le BindingContext avec le client filtré
                BindingContext = _currentClient;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    async private void Button_Clicked(object sender, EventArgs e)
    {
        if (_currentClient == null)
        {
            await DisplayAlert("Erreur", "Aucun client chargé", "OK");
            return;
        }

        await Navigation.PushAsync(new ModifCompte()
        {
            BindingContext = _currentClient
        });
    }
}