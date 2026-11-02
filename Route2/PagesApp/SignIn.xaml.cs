
using Route2.Services;

namespace Route2.PagesApp;

public partial class SignIn : ContentPage
{
    private readonly AuthService _authService;

    public SignIn(AuthService authService)
    {
        InitializeComponent();
        _authService = authService;
    }

    private async void ForgetPass(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ForgetPassword));
    }

    private async void OnSignUpTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignUp));
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text?.Trim() ?? string.Empty;
        string password = PasswordEntry.Text ?? string.Empty;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Atenção", "Preencha o e-mail e a senha para entrar.", "OK");
            return;
        }

        try
        {
            var result = await _authService.LoginAsync(email, password);

            if (result.IsSuccess)
            {
                await Shell.Current.GoToAsync(nameof(AssistantPage));
            }
            else
            {
                await DisplayAlert("Acesso negado", result.Message, "OK");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Erro no login: {ex}");

            await DisplayAlert(
                "Erro no login",
                "Não foi possível entrar. Verifique sua conexão com o servidor e tente novamente.",
                "OK");
        }
    }
    private async void NotLoginButtonClicked(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync(nameof(AssistantPage));
    }
}
