using Newtonsoft.Json;

namespace SicilyLinesResa;

public partial class ComptePage : ContentPage
{
    // Stocker le client dans un champ pour y accéder depuis le bouton
    private Client? _currentClient;
    private bool _isFirstLoad = true;

    public ComptePage()
    {
        InitializeComponent();
        BindingContext = null;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        loadCompteFromAPI();
    }

    public async void loadCompteFromAPI()
    {
        HttpClient clientHttp = new HttpClient();
        var restUrl = "http://localhost:5044/Profile?idClient=5804";
        try
        {
            var response = await clientHttp.GetAsync(restUrl);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                _currentClient = JsonConvert.DeserializeObject<Client>(json);
                BindingContext = _currentClient;
            }
            else
            {
                await DisplayAlert("Erreur", $"Impossible de charger les informations du client. Code d'erreur : {response.StatusCode}", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", $"Une erreur est survenue : {ex.Message}", "OK");
        }
    }

    async private void Button_Clicked(object sender, EventArgs e)
    {
        if (_currentClient != null)
            await Navigation.PushAsync(new ModifCompte(_currentClient));
    }

    async private void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}