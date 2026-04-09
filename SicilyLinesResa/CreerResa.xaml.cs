namespace SicilyLinesResa;

public partial class CreerResa : ContentPage
{
	public CreerResa()
	{
		InitializeComponent();
	}

    async private void Profil_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new ComptePage());
    }

}