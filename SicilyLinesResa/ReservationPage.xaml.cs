using Newtonsoft.Json;

namespace SicilyLinesResa;

public partial class ReservationPage : ContentPage
{
	public ReservationPage()
	{
		InitializeComponent();
	}

    async private void Profil_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ComptePage());
    }

    async private void afficherResa(object sender, EventArgs e)
    {
        HttpClient clientHttp = new HttpClient();
        var restUrl = "http://localhost:5044/Reservations?clientId=5804";
        clientHttp.BaseAddress = new Uri(restUrl);
        HttpResponseMessage response = await clientHttp.GetAsync(restUrl);
        var content = await response.Content.ReadAsStringAsync();
        var Items = JsonConvert.DeserializeObject<List<Reservation>>(content);

        Items = Items.Where(r => r.IdClient == 5804).ToList();
        if (Items != null)
        {
            ReservationsListView.ItemsSource = Items;
        }

    }
}