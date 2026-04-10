using Newtonsoft.Json;

namespace SicilyLinesResa;

public partial class ReservationPage : ContentPage
{
	public ReservationPage()
	{
		InitializeComponent();
        afficherResa();
	}

    async private void Profil_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ComptePage());
    }

    async private void afficherResa()
    {
        try
        {
            HttpClient clientHttp = new HttpClient();
            var restUrl = "http://localhost:5044/Reservation?idClient=5804";
            clientHttp.BaseAddress = new Uri(restUrl);

            HttpResponseMessage response = await clientHttp.GetAsync(restUrl);

            var content = await response.Content.ReadAsStringAsync();
            var Items = JsonConvert.DeserializeObject<List<Reservation>>(content);

            ReservationsListView.ItemsSource = Items;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", $"Une erreur est survenue : {ex.Message}", "OK");
        }


    }
}