namespace Route2.PagesApp;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    private async void OnBackTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnSignInClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignIn));
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignUp));
    }

    private async void OnAccessibilityClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Acessibilidade", "Configurações de acessibilidade em desenvolvimento.", "OK");
    }

    private async void OnPrivacyClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Privacidade", "Termos e privacidade em desenvolvimento.", "OK");
    }
}