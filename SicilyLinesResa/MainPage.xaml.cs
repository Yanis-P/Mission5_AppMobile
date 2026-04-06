namespace SicilyLinesResa
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            if (BindingContext is LoginInfo loginInfo)
            {
                string login = loginInfo.Login;
                string password = loginInfo.Password;

                // Exemple d'utilisation
                Console.WriteLine($"Connecté en tant que : {login}");
            }
        }

        async private void Profil_Clicked(object sender, EventArgs e)
        {
            if (BindingContext is not LoginInfo loginInfo)
                return;

            await Navigation.PushAsync(new ComptePage()
            {
                BindingContext = new LoginInfo
                {
                    Login = loginInfo.Login,
                    Password = loginInfo.Password
                }
            });
        }

        /*  private void OnCounterClicked(object sender, EventArgs e)
          {
              count++;

              if (count == 1)
                  CounterBtn.Text = $"Clicked {count} time";
              else
                  CounterBtn.Text = $"Clicked {count} times";

              SemanticScreenReader.Announce(CounterBtn.Text);
          }*/
    }

}
