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
            // Vérifier que le BindingContext contient bien les infos de connexion
            if (BindingContext is not LoginInfo loginInfo)
                return;

            HttpClient client = new HttpClient();
            // Appel direct par ID au lieu de récupérer tous les clients
            var restUrl = $"http://localhost:5044/Client/{loginInfo.Id}";
            client.BaseAddress = new Uri(restUrl);

            HttpResponseMessage response = await client.GetAsync(restUrl);

            if (!response.IsSuccessStatusCode)
            {
                await DisplayAlert("Erreur", "Impossible de récupérer le client", "OK");
                return;
            }

            var content = await response.Content.ReadAsStringAsync();

            // Désérialisation directe d'un seul client
            _currentClient = JsonConvert.DeserializeObject<Client>(content);

            // Mettre à jour le BindingContext avec le client filtré
            BindingContext = _currentClient;
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