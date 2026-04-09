namespace SicilyLinesResa;

public class LoginInfo
{
    public string Login { get; set; } = string.Empty;
    public string Id { get; set; } = string.Empty;
}

public partial class LogInPage : ContentPage
{
    public LogInPage()
    {
        InitializeComponent();
    }

    async private void Button_Clicked(object sender, EventArgs e)
    {
        HttpClient client = new HttpClient();
        var restURL = "http://localhost:5044/LogIn?login=" + logIn.Text + "&password=" + mdp.Text;
        client.BaseAddress = new Uri(restURL);
        HttpResponseMessage response = await client.GetAsync(restURL);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            if (Convert.ToBoolean(content))
            {
                await Navigation.PushAsync(new MainPage()
                {
                    BindingContext = new LoginInfo
                    {
                        Login = logIn.Text,
                        Id = 1.ToString()
                    }
                });
            }
            else
            {
                await DisplayAlert("Alerte", "Connexion user refusée", "Cancel");
            }
        }
        else
        {
            await DisplayAlert("Alerte", "Pas de connexion avec l'API", "Cancel");
        }
    }
}