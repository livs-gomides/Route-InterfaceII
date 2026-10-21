using Route2.Services;

namespace Route2.PagesApp;

public partial class SignIn : ContentPage
{
    private readonly Services.AuthService _authService = new();
    public SignIn()
	{
		InitializeComponent();
	}
    private async void ForgetPass(object sender, EventArgs e)
    {
                await Shell.Current.GoToAsync(
                    nameof(ForgetPassword));  
    }
    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Atenção", "Preencha o e-mail e a senha para entrar.", "OK");
            return;
        }

        bool isSuccess = await _authService.LoginAsync(email, password);

        if (isSuccess)
        {

            Application.Current.MainPage = new NavigationPage(new StartPage());
        }
        else
        {
            await DisplayAlert("Acesso Negado", "E-mail ou senha incorretos.", "OK");
        }
    }
}