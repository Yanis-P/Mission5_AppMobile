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
                    Login = loginInfo.Login
                }
            });
        }

    }

}
