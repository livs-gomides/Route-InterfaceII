namespace Route2.PagesApp;

public partial class SignIn : ContentPage
{
	public SignIn()
	{
		InitializeComponent();
	}
    private async void ForgetPass(object sender, EventArgs e)
    {
                await Shell.Current.GoToAsync(
                    nameof(ForgetPassword));  
    }
    private async void OnAllowClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(
                   nameof(AssistantPage));
    }
}