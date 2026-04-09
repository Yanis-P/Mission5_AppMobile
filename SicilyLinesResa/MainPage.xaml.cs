namespace SicilyLinesResa
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }

        async private void Profil_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ComptePage());
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReservationPage());
        }

        async private void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreerResa());
        }
    }

}
