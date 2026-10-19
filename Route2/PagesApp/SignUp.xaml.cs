namespace Route2.PagesApp;

public partial class SignUp : ContentPage
{
	public SignUp()
	{
		InitializeComponent();
	}
    private async void OnAllowClicked(object sender, EventArgs e)
    {
                await Shell.Current.GoToAsync(
                    nameof(SignIn));      
    }

    
}